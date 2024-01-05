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
            PrimaryPurpose = Purpose.DataAnalysis,
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

        //Adding a Dictionary
        Dictionary<string, int> languageScores = new Dictionary<string, int>();

        //User requirements
        Purpose userPurpose = Purpose.DataAnalysis;

        Console.WriteLine("Enter your Performance rate: ");
        int userPerformance = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter your Scalability rate: ");
        int userScalability = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter your Community rate: ");
        int userCommunityScore = Convert.ToInt32(Console.ReadLine());

        if (python.MatchesPurpose(userPurpose))
        {
            int pythonScore = python.CalculateTotalScore(userPerformance, userScalability, userCommunityScore);
            languageScores["Python"] = pythonScore;
        }
        
        if (JavaScript.MatchesPurpose(userPurpose))
        {
            int JavaScriptScore = JavaScript.CalculateTotalScore(userPerformance, userScalability, userCommunityScore);
            languageScores["JavaScript"] = JavaScriptScore;
        }


        //Find the language with the highest score
        int highestScore = int.MinValue;
        string suggestedLanguage = "";

        foreach(var kvp in languageScores)
        {
            if(kvp.Value > highestScore)
            {
                highestScore = kvp.Value;
                suggestedLanguage = kvp.Key;
            }
        }

        Console.WriteLine($"Based on your requirements, {suggestedLanguage} scored {highestScore}. It might be a good fit!");
    }
}
