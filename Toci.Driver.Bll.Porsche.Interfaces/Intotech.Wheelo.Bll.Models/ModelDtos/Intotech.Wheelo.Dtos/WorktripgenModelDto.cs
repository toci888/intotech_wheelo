using Intotech.Common.Bll.ChorDtoBll.Dto;
using Toci.Driver.Database.Persistence.Models;


namespace Intotech.Wheelo.Bll.Models.ModelDtos.Intotech.Wheelo.Dtos;

public class WorktripgenModelDto : DtoCollectionBase<Worktripgen, WorktripgenModelDto, List<Worktripgen>, List<WorktripgenModelDto>>
{
    public int Id { get; set; }
    public int Idaccount { get; set; }
    public string Searchid { get; set; }
    public Double Latitudefrom { get; set; }
    public Double Longitudefrom { get; set; }
    public Double Latitudeto { get; set; }
    public Double Longitudeto { get; set; }
    public int Idgeographiclocationfrom { get; set; }
    public int Idgeographiclocationto { get; set; }
    public string Streetfrom { get; set; }
    public string Streetto { get; set; }
    public string Cityfrom { get; set; }
    public string Cityto { get; set; }
    public string Postcodefrom { get; set; }
    public string Postcodeto { get; set; }
    public TimeOnly Fromhour { get; set; }
    public TimeOnly Tohour { get; set; }
    public Double Acceptabledistance { get; set; }
    public int Driverpassenger { get; set; }
    public DateTime Createdat { get; set; }
}
