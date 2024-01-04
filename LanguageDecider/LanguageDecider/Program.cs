public enum Purpose
{
    WebDevelopment,
    MobileApp,
    DataAnalysis
}

public class ProgrammingLanguage
{
    public string Name { get; set; }
    public Purpose PrimaryPurpose { get; set; }
    public int PerformanceScore { get; set; }
    public int ScalabilityScore { get; set; }
    public int CommunityScore { get; set; }
    public int UserScalabilityScore { get; private set; }

    //Method to check if the language matches the specified purpose
    public bool MatchesPurpose(Purpose applicationPurpose)
    {
        return PrimaryPurpose == applicationPurpose;
    }

    //Method to calculate total score bed on user requirements
    public int CalculateTotalScore(int userPerformance, int userScalability, int userCommunityScore)
    {
        int totalScore = (PerformanceScore * userPerformance) + (UserScalabilityScore * userScalability) + (CommunityScore * userCommunityScore);
        return totalScore;
    }
}

//user example
class MainApp
{
    static void Main()
    {
        //Program language and their attributes
        ProgrammingLanguage python = new ProgrammingLanguage
        {
            Name = "Python",
            PrimaryPurpose = Purpose.WebDevelopment,
            PerformanceScore = 8,
            ScalabilityScore = 7,
            CommunityScore = 9
        };

        ProgrammingLanguage JavaScript = new ProgrammingLanguage
        {
            Name = "JavaScript",
            PrimaryPurpose = Purpose.WebDevelopment,
            PerformanceScore = 7,
            ScalabilityScore = 8,
            CommunityScore = 9
        };

        //User requirements
        Purpose userPurpose = Purpose.WebDevelopment;
        int userPerformance = 7;
        int userScalability = 8;
        int userCommunityScore = 9;

        if (python.MatchesPurpose(userPurpose))
        {
            int pythonScore = python.CalculateTotalScore(userPerformance, userScalability, userCommunityScore);
            Console.WriteLine($"Based on your requirements, Python Scored {pythonScore}. It might be a good fit");
        }
        
        if (JavaScript.MatchesPurpose(userPurpose))
        {
            int JavaScriptScore = JavaScript.CalculateTotalScore(userPerformance, userScalability, userCommunityScore);
            Console.WriteLine($"Based on your requirements, Javascript Scored {JavaScriptScore}. It might be a good fit");
        }

    }
}
