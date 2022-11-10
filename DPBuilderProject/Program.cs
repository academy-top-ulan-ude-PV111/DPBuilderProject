using System.Text;

namespace DPBuilderProject
{
    interface IBuilder<T>
    {
        T CreateObject();
    }
    class Email
    {
        public string? From { set; get; }
        public string? To { set; get; }
        public string? Subject { set; get; }
        public string? Body { set; get; }
        public Encoding? BodyEncoding { set; get; }
        public string? CopyTo { set; get; }
        public FileInfo? Attach { set; get; }

        public Email() { }
    }

    class EmailBuilder : IBuilder<Email>
    {
        Email email = new Email();

        public EmailBuilder From(string from)
        {
            email.From = from;
            return this;
        }

        public EmailBuilder To(string to)
        {
            email.To = to;
            return this;
        }

        public EmailBuilder Subject(string subject)
        {
            email.Subject = subject;
            return this;
        }

        public EmailBuilder Body(string body, Encoding encoding)
        {
            email.Body = body;
            email.BodyEncoding = encoding;
            return this;
        }

        public EmailBuilder CopyTo(string copyto)
        {
            email.CopyTo = copyto;
            return this;
        }
        public EmailBuilder Attach(string attach)
        {
            email.Attach = new FileInfo(attach);
            return this;
        }
        public Email CreateObject()
        {
            return email;
        }
    }

    class StandartEmail
    {
        public static Email Create(string from, string to, string subject)
        {
            return new EmailBuilder().From(from).To(to).Subject(subject).CreateObject();
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Email email = new EmailBuilder().From("efimov@mail.ru")
                                            .To("ivanov@gmail.com")
                                            .Subject("Отчет за октябрь")
                                            .Body("Пришли отчет немедленно", Encoding.UTF8)
                                            .Attach("file.docx")
                                            .CreateObject();
        }
    }
}