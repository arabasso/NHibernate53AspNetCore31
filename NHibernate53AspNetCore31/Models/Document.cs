using System;

namespace NHibernate53AspNetCore31.Models
{
    public class Document
    {
        public virtual long Id { get; set; }
        public virtual int Number { get; set; }
        public virtual int Year { get; set; }
        public virtual DateTime Date { get; set; }
        public virtual string Subject { get; set; }
    }
}