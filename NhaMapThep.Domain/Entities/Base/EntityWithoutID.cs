using System.ComponentModel.DataAnnotations.Schema;

namespace NhaMapThep.Domain.Entities.Base
{
    public abstract class EntityWithoutID : IDisposable
    {
        protected EntityWithoutID()
        {
            
            NgayTao = NgayCapNhatCuoi = DateTime.Now;
        }
        public string? NguoiTaoID { get; set; }      
        public DateTime NgayTao { get; set; }

        public string? NguoiCapNhatID { get; set; }     
        public DateTime NgayCapNhatCuoi { get; set; }


        [NotMapped]
        private bool IsDisposed { get; set; }

        #region Dispose
        public void Dispose()
        {
            Dispose(isDisposing: true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool isDisposing)
        {
            if (!IsDisposed)
            {
                if (isDisposing)
                {
                    DisposeUnmanagedResources();
                }

                IsDisposed = true;
            }
        }

        protected virtual void DisposeUnmanagedResources()
        {
        }

        ~EntityWithoutID()
        {
            Dispose(isDisposing: false);
        }
        #endregion Dispose
    }
}
