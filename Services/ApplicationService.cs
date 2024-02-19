using System;

namespace Backend.Services
{
    public class ApplicationService
    {
        //Here you should create Menu which your Console application will show to user
        //User should be able to choose between: 1. Movie star 2. Calculate Net salary 3. Exit
        private readonly IMovieStarService _movieStarService;
        private readonly ISalaryService _salaryService;
        public ApplicationService(IMovieStarService movieStarService, ISalaryService salaryService)
        {
            _movieStarService = movieStarService;
            _salaryService = salaryService;
        }

        public void Run()
        {
            while (true)
            {
                Console.WriteLine("Please select an option:");
                Console.WriteLine("1. View Movie Stars List");
                Console.WriteLine("2. Calculate Net Salary");
                Console.WriteLine("3. Exit");
                var userChoice = DisplayMenu();
                switch (userChoice)
                {
                    case 1:
                        _movieStarService.Run();
                        break;
                    case 2:
                        _salaryService.Calculate();
                        break;
                    case 3:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid option, please select 1, 2 or 3.");
                        break;
                }
            }
        }

        private int DisplayMenu()
        {

            switch (Console.ReadLine())
            {
                case "1":
                    return 1;
                case "2":
                    return 2;
                case "3":
                    return 3;
                default:
                    return 0;
            }
        }

    }
}
