// <auto-generated />
namespace AutoGreeter.Migrations
{
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Migrations.Infrastructure;
    
    public sealed partial class AddValidationToExistingFields : IMigrationMetadata
    {
        string IMigrationMetadata.Id
        {
            get { return "201202120840357_AddValidationToExistingFields"; }
        }
        
        string IMigrationMetadata.Source
        {
            get { return null; }
        }
        
        string IMigrationMetadata.Target
        {
            get { return "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"; }
        }
    }
}