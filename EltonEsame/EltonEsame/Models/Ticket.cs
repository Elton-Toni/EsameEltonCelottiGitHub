namespace EltonEsame.Models
{
  using System;
  using System.Collections.Generic;
  using System.ComponentModel.DataAnnotations;
  using System.ComponentModel.DataAnnotations.Schema;
  using System.Data.Entity.Spatial;

  [Table("Ticket")]
  public partial class Ticket
  {
    [Key]
    public int IdTicket { get; set; }

    public int? RegistryId { get; set; }

    public int? InternaPersonId { get; set; }

    [Column(TypeName = "datetime2")]
    public DateTime? RequestDate { get; set; }

    [Column(TypeName = "datetime2")]
    public DateTime? ClosingDate { get; set; }

    public int? RequestState { get; set; }

    [StringLength(50)]
    [Display(Name = "Titolo della richiesta")]
    public string RequestTitle { get; set; }

    [StringLength(250)]
    [Display(Name = "Descrizione della richiesta")]
    public string RequestDescription { get; set; }

    [StringLength(250)]
    [Display(Name = "Descrizione della risposta")]
    public string ResponseDescription { get; set; }

    public virtual Registry Registry { get; set; }

    public virtual Registry Registry1 { get; set; }
  }
}
