using System.Linq;
using System.Web.Http;
using System.Web.Http.Data.EntityFramework;

namespace AutoGreeterMVC4.Controllers
{
    public partial class AutoGreeterMVC4Controller : DbDataController<AutoGreeterMVC4.Models.AutoGreeterMVC4Context>
    {
        public IQueryable<AutoGreeterMVC4.Models.TodoItem> GetTodoItems() {
            return DbContext.TodoItems.OrderBy(t => t.TodoItemId);
        }

        public void InsertTodoItem(AutoGreeterMVC4.Models.TodoItem entity) {
            InsertEntity(entity);
        }

        public void UpdateTodoItem(AutoGreeterMVC4.Models.TodoItem entity) {
            UpdateEntity(entity);
        }

        public void DeleteTodoItem(AutoGreeterMVC4.Models.TodoItem entity) {
            DeleteEntity(entity);
        }
    }
}
