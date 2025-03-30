using ReceiptProcessorApi.Models;
using AutoMapper;

namespace ReceiptProcessorApi.Mappers;
public class ReceiptMapper : Profile{
    public ReceiptMapper() {
        CreateMap<ReceiptPayload, Receipt>();
        CreateMap<ReceiptPayloadLineItem, ReceiptLineItem>();
    }
}