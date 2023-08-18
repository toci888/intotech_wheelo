using Intotech.Common.Bll.ChorDtoBll.Dto;
using Intotech.Common.Bll.Interfaces;
using Toci.Driver.Database.Persistence.Models;

namespace Intotech.Wheelo.Bll.Models.ModelDtos.Intotech.Wheelo.Dtos;


public class StatisticstripModelDto : DtoModelBase
{
    public int Id { get; set; }
    public DateOnly Tripdate { get; set; }
    public int Tripcars { get; set; }
    public int Trippeople { get; set; }
    public int Idgeographicregion { get; set; }
}
