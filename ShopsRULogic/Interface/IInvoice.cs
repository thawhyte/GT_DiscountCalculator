using ShopsRUsModel.DTOs;
using ShopsRUsModel.DTOs.InvoiceDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopsRULogic.Interface
{
    public interface IInvoice
    {
        Task<GetTotalInvoiceDetailsDTO> GetInvoiceDetailsAsync(InvoiceRequest invoiceRequest);

    }
}
