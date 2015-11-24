using CAR.DAL.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CAR.DAL
{
    public class EmailRepository: IDisposable
    {
        private CarContext db = new CarContext();

        public bool EmailExists(string email)
        {
            return db.Emails.Any(e => e.EmailAddress.Equals(email, StringComparison.InvariantCultureIgnoreCase));
        }

        public async Task Add(string email)
        {
            db.Emails.Add(new Email()
            {
                DateSubscribed = DateTime.Now,
                EmailAddress = email
            });

            await db.SaveChangesAsync();
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }
                disposedValue = true;
            }
        }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            Dispose(true);
        }
        #endregion

    }
}
