using MediatR;
using Domain;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Activity = Domain.Activity;
using System.Diagnostics;
using AutoMapper;

namespace Application.Activities
{
    public class Edit
    {
        public class Command : IRequest
        {
            public Activity Activity { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext _context;
            public IMapper _mapper { get; }

            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var activity = await _context.Activities.FindAsync(request.Activity.Id);

                //Using Automapper
                _mapper.Map(request.Activity, activity);

                ////general way to update
                //if (activity != null)
                //{
                //    activity.Title = request.Activity.Title;
                //    activity.Date = request.Activity.Date;
                //    activity.Description = request.Activity.Description;
                //    activity.Category = request.Activity.Category;
                //    activity.City = request.Activity.City;
                //    activity.Venue = request.Activity.Venue;
                //}
                //_context.Activities.Update(activity);

                await _context.SaveChangesAsync();
                return Unit.Value;
            }
        }
    }
}
