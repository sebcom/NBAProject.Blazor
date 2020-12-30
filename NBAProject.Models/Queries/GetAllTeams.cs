using System.Collections.Generic;
using MediatR;
using NBAProject.Models.Documents;

namespace NBAProject.Models.Queries
{
    public class GetAllTeams : IRequest<IEnumerable<Team>>
    {
    }
}