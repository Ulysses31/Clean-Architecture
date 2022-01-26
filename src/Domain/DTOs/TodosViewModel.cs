using System.Collections.Generic;

namespace CleanArchitecture.Domain.DTOs
{
    public class TodosViewModel
    {
        public IList<PriorityLevelDto> PriorityLevels { get; set; }

        public IList<TodoListDto> Lists { get; set; }
    }
}
