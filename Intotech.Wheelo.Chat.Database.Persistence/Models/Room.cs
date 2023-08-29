using Intotech.Common.Bll.Interfaces;
using System;
using System.Collections.Generic;

namespace Intotech.Wheelo.Chat.Database.Persistence.Models;

public partial class Room : ModelBase
{
    public int Id { get; set; }

    public string Roomid { get; set; } = null!;

    public string Owneremail { get; set; } = null!;

    public int Owneridaccount { get; set; }

    public string? Roomname { get; set; }

    public DateTime? Createdat { get; set; }

    public virtual ICollection<Accountsidentifier> Accountsidentifiers { get; } = new List<Accountsidentifier>();

    public virtual ICollection<Conversationinvitation> Conversationinvitations { get; } = new List<Conversationinvitation>();

    public virtual ICollection<Message> Messages { get; } = new List<Message>();

    public virtual ICollection<Roomsaccount> Roomsaccounts { get; } = new List<Roomsaccount>();
}
