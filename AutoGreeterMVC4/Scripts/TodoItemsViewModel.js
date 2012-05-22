/// <reference path="_references.js" />

(function (window, undefined) {
    // Define the "MyApp" namespace
    var MyApp = window.MyApp = window.MyApp || {};

    // TodoItem class
    var entityType = "TodoItem:#AutoGreeterMVC4.Models";
    MyApp.TodoItem = function (data) {
        var self = this;

        // Underlying data
        self.TodoItemId = ko.observable(data.TodoItemId);
        self.Title = ko.observable(data.Title);
        self.IsDone = ko.observable(data.IsDone);
        upshot.addEntityProperties(self, entityType);
    }

    // TodoItemsViewModel class
    MyApp.TodoItemsViewModel = function (options) {
        var self = this;

        // Private properties
        var dataSourceOptions = {
            providerParameters: { url: options.serviceUrl, operationName: "GetTodoItems" },
            entityType: entityType,
            bufferChanges: true,
            mapping: MyApp.TodoItem
        };
        var gridDataSource = new upshot.RemoteDataSource(dataSourceOptions);
        var editorDataSource = new upshot.RemoteDataSource(dataSourceOptions);

        // Data
        self.todoItems = gridDataSource.getEntities();
        self.editingTodoItem = editorDataSource.getFirstEntity();
        self.successMessage = ko.observable().extend({ notify: "always" });
        self.errorMessage = ko.observable().extend({ notify: "always" });
        self.paging = new upshot.PagingModel(gridDataSource, {
            onPageChange: function (pageIndex, pageSize) {
                self.nav.navigate({ page: pageIndex, pageSize: pageSize });
            }
        });
        self.validationConfig = $.extend({
            resetFormOnChange: self.editingTodoItem,
            submitHandler: function () { self.saveEdit() }
        }, editorDataSource.getEntityValidationRules());

        // Client-side navigation
        self.nav = new NavHistory({
            params: { edit: null, page: 1, pageSize: 10 },
            onNavigate: function (navEntry, navInfo) {
                self.paging.moveTo(navEntry.params.page, navEntry.params.pageSize);

                // Wipe out any old data so that it is not displayed in the UI while new data is being loaded 
                editorDataSource.revertChanges();
                editorDataSource.reset();

                if (navEntry.params.edit) {
                    
                    if (navEntry.params.edit == "new") {
                        // Create and begin editing a new todoItem instance
                        editorDataSource.getEntities().push(new MyApp.TodoItem({}));
                    } else {
                        // Load and begin editing an existing todoItem instance
                        editorDataSource.setFilter({ property: "TodoItemId", value: Number(navEntry.params.edit) }).refresh();
                    }
                } else {
                    // Not editing, so load the requested page of data to display in the grid
                    gridDataSource.refresh();
                }
            }
        }).initialize({ linkToUrl: true });

        // Public operations
        self.saveEdit = function () {
            editorDataSource.commitChanges(function () {
                self.successMessage("Saved TodoItem").errorMessage("");
                self.showGrid();
            });
        }
        self.revertEdit = function () { editorDataSource.revertChanges() }
        self.editTodoItem = function (todoItem) { self.nav.navigate({ edit: todoItem.TodoItemId() }) }
        self.showGrid = function () { self.nav.navigate({ edit: null }) }
        self.createTodoItem = function () { self.nav.navigate({ edit: "new" }) }
        self.deleteTodoItem = function (todoItem) {
            editorDataSource.deleteEntity(todoItem);
            editorDataSource.commitChanges(function () {
                self.successMessage("Deleted TodoItem").errorMessage("");
                self.showGrid();
            });
        };

        // Error handling
        var handleServerError = function (httpStatus, message) {
            if (httpStatus === 200) {
                // Application domain error (e.g., validation error)
                self.errorMessage(message).successMessage("");
            } else {
                // System error (e.g., unhandled exception)
                self.errorMessage("Server error: HTTP status code: " + httpStatus + ", message: " + message).successMessage("");
            }
        }
        
        gridDataSource.bind({ refreshError: handleServerError, commitError: handleServerError });
        editorDataSource.bind({ refreshError: handleServerError, commitError: handleServerError });
    }
})(window);

