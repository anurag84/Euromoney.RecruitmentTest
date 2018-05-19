using Ninject;
using Ninject.Parameters;
using System;

namespace ContentConsole
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            //Kernel declaration and DI can be moved into ModuleClass(), but for time constriant I am declaring inside Main().
            var kernel = new StandardKernel();
            kernel.Bind<IFunctionality>().To<Functionality>();
            kernel.Bind<IDatabase>().To<DatabaseCont>();

            //Added choice feature to excute individual story.
            Console.WriteLine("Which Story you would like to run (1,2,3 or 4):");
            var choice = Console.ReadLine();

            //To speed up and not to spend time in defining IChoice or IStory as those are not going to be part of actual solution.
            if (choice.ToString() == "1")
            {
                Story1(kernel);
            }
            else if (choice.ToString() == "2")
            {
                Story2(kernel);
            }
            else if (choice.ToString() == "3")
            {
                Story3(kernel);
            }
            else
            {
                Story4(kernel);
            }
        }

        public static void Story1(IKernel kernel)
        {
            var databaseService = kernel.Get<IDatabase>();
            var functionalityService = kernel.Get<IFunctionality>(new IParameter[] { new Parameter("dbContext", databaseService, false) });
            var content = GetUserContent();
            var countReturn = functionalityService.CheckNegativeCount(content);

            //Below can be removed from here and added to OutputClass which can be shared by other stories as well.
            Console.WriteLine("Scanned the text:");
            Console.WriteLine(functionalityService.FilterOutNegativeWords(content, true));
            Console.WriteLine("Total Number of negative words: " + countReturn);
            Console.WriteLine("Press ANY key to exit.");
            Console.ReadKey();
        }

        public static void Story2(IKernel kernel)
        {
            var databaseService = kernel.Get<IDatabase>();
            var currentList = databaseService.GetNegativeWords();

            Console.WriteLine("Current Negative Words :");
            currentList.ForEach(Console.WriteLine);

            Console.WriteLine("Type new Negative word to be added to database:");
            var word = Console.ReadLine();

            currentList = databaseService.AddNegativeWords(word);

            Console.WriteLine("New list of Negative Words :");
            currentList.ForEach(Console.WriteLine);

            Console.ReadKey();
        }

        public static void Story3(IKernel kernel)
        {
            var databaseService = kernel.Get<IDatabase>();
            var functionalityService = kernel.Get<IFunctionality>(new IParameter[] { new Parameter("dbContext", databaseService, false) });
            var content = GetUserContent();
            var contentReturn = functionalityService.FilterOutNegativeWords(content, true);

            Console.WriteLine("Processed Content :");
            Console.WriteLine(contentReturn);
            Console.WriteLine("Press ANY key to exit.");
            Console.ReadKey();
        }


        public static void Story4(IKernel kernel)
        {
            var databaseService = kernel.Get<IDatabase>();
            var functionalityService = kernel.Get<IFunctionality>(new IParameter[] { new Parameter("dbContext", databaseService, false) });
            var content = GetUserContent();
            var countReturn = functionalityService.CheckNegativeCount(content);
            var filterOutFlag = true;

            //Not sure if I got the quesiton right, I have assume that the intention is to add a way by which filteration can be disable.
            Console.WriteLine("Do you want to disable filter out? (y/n): ");
            var userChoice = Console.ReadLine();

            if (userChoice.ToString().ToLower() == "y")
            {
                filterOutFlag = false;
            }

            Console.WriteLine("Total Number of negative words: " + countReturn);
            Console.WriteLine(functionalityService.FilterOutNegativeWords(content, filterOutFlag));
            Console.WriteLine("Press ANY key to exit.");
            Console.ReadKey();
        }

        //This can be moved and scope separtely but adding here to speed up.
        public static string GetUserContent()
        {
            string content =
              "The weather in Manchester in winter is bad. It rains all the time - it must be horrible for people visiting.";

            Console.WriteLine("Enter the text for scanning or leave blank for default");

            var userContent = Console.ReadLine();

            if (userContent.ToString() != "")
            {
                content = userContent;
            }
            return content;
        }
    }

}
