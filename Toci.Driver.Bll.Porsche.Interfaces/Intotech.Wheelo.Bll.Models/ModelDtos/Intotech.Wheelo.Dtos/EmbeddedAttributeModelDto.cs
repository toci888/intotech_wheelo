using Intotech.Common.Bll.ChorDtoBll.Dto;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Bll.Models.ModelDtos.Intotech.Wheelo.Dtos;

public class EmbeddedAttributeModelDto : DtoBase<EmbeddedAttribute, EmbeddedAttributeModelDto>
{
    public Object TypeId { get; set; }
}
