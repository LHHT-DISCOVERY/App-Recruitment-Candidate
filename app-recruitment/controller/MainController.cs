using app_recruitment.model;
using app_recruitment.service;
using app_recruitment.validate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app_recruitment.controller
{

    internal class MainController
    {
        ICandidateService candidateService = new CandidateServiceImp();
        public void controller()
        {

            while (true)
            {
                Console.WriteLine("--- Please Enter the function ---");
                Console.WriteLine("1. Add Candiate ");
                Console.WriteLine("2. View Candidate ");
                Console.WriteLine("3. Update Candidate");
                Console.WriteLine("4. Delete Candidate ");
                Console.WriteLine("5. Sort  Candiate by Birthday");
                Console.WriteLine("6. View Full Name Candidate");
                Console.WriteLine("0. Exit");
                int choice = ValidateNumber.validateNumber();
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("--- Add Candidate ---");
                        candidateService.enterCanidate();
                        candidateService.getAll<Candidate>().ForEach(candidate => Console.WriteLine(candidate));
                        break;
                    case 2:
                        Console.WriteLine("--- View Candidate  ---");
                        List<Candidate> listCandidate = candidateService.getAll<Candidate>();
                        foreach (Candidate candidate in listCandidate)
                        {
                            Console.WriteLine(candidate.ToString());
                        }
                        break;
                    case 3:
                        Console.WriteLine("--- Update Candidate  ---");
                        while (true)
                        {
                            Console.Write("Entern CandidateID You Want to Update: ");
                            int candidateID = Convert.ToInt32(Console.ReadLine());
                            if (candidateService.findCandidateById(candidateID) is null)
                            {
                                Console.WriteLine("CANDIDATE ID NOT FOUND IN DATABASE");
                            }
                            else
                            {
                                candidateService.updateCandidate(candidateID);
                                break;
                            }
                        }
                        break;
                    case 4:
                        Console.WriteLine("--- Delete Candidate  ---");
                        while (true)
                        {
                            Console.Write("Enter Candidate ID Want To Delete: ");
                            int id = Convert.ToInt32(Console.ReadLine());
                            if (candidateService.findCandidateById(id) is null)
                            {
                                Console.WriteLine("ID CANDIDATE DOES NOT EXIST IN DATABASE");
                            }
                            else
                            {
                                candidateService.deleteCandidade(id);
                                break;
                            }
                        }
                        candidateService.viewFullNameCandidate();
                        break;
                    case 5:
                        Console.WriteLine("--- Sort  Candiate by Birthday  ---");
                        Console.WriteLine("--- Before sort --- ");
                        int count = 0;
                        List<Candidate> listCa = candidateService.getAll<Candidate>(); 
                        foreach (Candidate candidate in listCa)
                        {
                            Console.WriteLine(candidate.ToString());
                        }
                        Console.WriteLine("--- After sort --- ");
                        candidateService.sortByTypeAndBirthDayService(listCa);
                        foreach (Candidate candidate in listCa)
                        {
                            Console.WriteLine(candidate.ToString());
                            count++;
                        }
                        Console.WriteLine("Number of candidate is : " + count);
                        break;
                    case 6:
                        Console.WriteLine("--- View Full Name Candidate ---");
                        candidateService.viewFullNameCandidate();
                        break;
                    case 0:
                        Console.WriteLine("Thank You");
                        return;
                    default:
                        Console.WriteLine("------- Please Choose Function 1,2,3,4,5,6 ---------");
                        break;
                }
            }
        }
    }
}
