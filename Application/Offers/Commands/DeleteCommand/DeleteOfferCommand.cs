﻿using MediatR;
using RealtService.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealtService.Application.Offers.Commands.DeleteCommand
{
    public class DeleteOfferCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
