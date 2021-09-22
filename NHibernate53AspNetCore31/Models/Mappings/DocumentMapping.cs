using NHibernate;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace NHibernate53AspNetCore31.Models.Mappings
{
    public class DocumentMapping :
        ClassMapping<Document>
    {
        public DocumentMapping()
        {
            Table("Document");
            Id(m => m.Id, p => p.Generator(Generators.Identity));
            Property(m => m.Number);
            Property(m => m.Year);
            Property(m => m.Date, p => p.Type(NHibernateUtil.Date));
            Property(m => m.Subject, p => p.Length(2048));
        }
    }
}
