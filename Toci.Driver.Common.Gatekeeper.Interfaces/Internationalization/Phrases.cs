using System.Linq.Expressions;

namespace Toci.Driver.Common.Gatekeeper.Interfaces.Internationalization
{
    public static class Phrases
    {
        public static Phrase UnknownDatabaseError = new Phrase() { Tag = "_unknown_database_error", Text = "Unknown database error" };
        public static Phrase DatabaseIntegrityError = new Phrase() { Tag = "_database_integrity_error", Text = "Database integrity error" };
    }
}