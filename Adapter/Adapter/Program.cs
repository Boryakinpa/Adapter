internal class Program
{
    private static void Main(string[] args)
    {
        Adapter adapter = new Adapter();
        ComputerGame computerGame = new(name: "FFF", budgetInMillionsOfDollars: 65, minimumGpuMemoryInMegabytes: 2048, pegiAgeRating: 0,
            diskSpaceNeededInGB: 10, ramNeededInGb: 8, coresNeeded: 10, coreSpeedInGhz:10);
        adapter.adaptee = computerGame;
        Console.WriteLine(adapter.isTripleAGame());
    }
}

public class ComputerGame
{
    private string name;
    private PegiAgeRating pegiAgeRating;
    private double budgetInMillionsOfDollars;
    private int minimumGpuMemoryInMegabytes;
    private int diskSpaceNeededInGB;
    private int ramNeededInGb;
    private int coresNeeded;
    private double coreSpeedInGhz;

    public ComputerGame(string name,
                        PegiAgeRating pegiAgeRating,
                        double budgetInMillionsOfDollars,
                        int minimumGpuMemoryInMegabytes,
                        int diskSpaceNeededInGB,
                        int ramNeededInGb,
                        int coresNeeded,
                        double coreSpeedInGhz)
    {
        this.name = name;
        this.pegiAgeRating = pegiAgeRating;
        this.budgetInMillionsOfDollars = budgetInMillionsOfDollars;
        this.minimumGpuMemoryInMegabytes = minimumGpuMemoryInMegabytes;
        this.diskSpaceNeededInGB = diskSpaceNeededInGB;
        this.ramNeededInGb = ramNeededInGb;
        this.coresNeeded = coresNeeded;
        this.coreSpeedInGhz = coreSpeedInGhz;
    }

    public string getName()
    {
        return name;
    }

    public PegiAgeRating getPegiAgeRating()
    {
        return pegiAgeRating;
    }

    public double getBudgetInMillionsOfDollars()
    {
        return budgetInMillionsOfDollars;
    }

    public int getMinimumGpuMemoryInMegabytes()
    {
        return minimumGpuMemoryInMegabytes;
    }

    public int getDiskSpaceNeededInGB()
    {
        return diskSpaceNeededInGB;
    }

    public int getRamNeededInGb()
    {
        return ramNeededInGb;
    }

    public int getCoresNeeded()
    {
        return coresNeeded;
    }

    public double getCoreSpeedInGhz()
    {
        return coreSpeedInGhz;
    }
}

public enum PegiAgeRating
{
    P3, P7, P12, P16, P18
}

public class Requirements
{
    private int gpuGb;
    private int HDDGb;
    private int RAMGb;
    private double cpuGhz;
    private int coresNum;

    public Requirements(int gpuGb,
                        int HDDGb,
                        int RAMGb,
                        double cpuGhz,
                        int coresNum)
    {
        this.gpuGb = gpuGb;
        this.HDDGb = HDDGb;
        this.RAMGb = RAMGb;
        this.cpuGhz = cpuGhz;
        this.coresNum = coresNum;
    }

    public int getGpuGb()
    {
        return gpuGb;
    }

    public int getHDDGb()
    {
        return HDDGb;
    }

    public int getRAMGb()
    {
        return RAMGb;
    }

    public double getCpuGhz()
    {
        return cpuGhz;
    }

    public int getCoresNum()
    {
        return coresNum;
    }
}

public interface PCGame
{
    string getTitle();
    int getPegiAllowedAge();
    bool isTripleAGame();
    Requirements getRequirements();
}

public class Adapter : PCGame
{
    public ComputerGame adaptee;
    
    public int getPegiAllowedAge()
    {
        return (int)adaptee.getPegiAgeRating();
    }

    public Requirements getRequirements()
    {
        Requirements requirements = new Requirements(gpuGb: adaptee.getMinimumGpuMemoryInMegabytes()/1024, HDDGb: adaptee.getDiskSpaceNeededInGB(), RAMGb: adaptee.getRamNeededInGb(),
            cpuGhz: adaptee.getCoreSpeedInGhz(), coresNum: adaptee.getMinimumGpuMemoryInMegabytes());
        return requirements;
    }

    public string getTitle()
    {
        return adaptee.getName();
    }

    public bool isTripleAGame()
    {
        return adaptee.getBudgetInMillionsOfDollars() > 50;
    }
}