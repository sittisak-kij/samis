using Microsoft.EntityFrameworkCore;
using samis.Models;

namespace samis.Data
{
    public class SamisDbContext : DbContext
    {
        public SamisDbContext(DbContextOptions<SamisDbContext> option) : base(option)
        {

        }

        public DbSet<ActivityInformation> ActivityInformations { get; set; }
        public DbSet<ActivityType> ActivityTypes { get; set; }
        public DbSet<ActivityUnit> ActivityUnits { get; set; }
        public DbSet<Advisor> Advisors { get; set; }
        public DbSet<AdvisorPosition> AdvisorPositions { get; set; }
        public DbSet<Budget> Bugets { get; set; }
        public DbSet<BudgetStatus> BudgetStatus { get; set; }
        public DbSet<BudgetType> BudgetTypes { get; set; }
        public DbSet<BudgetDescription> BudgetDescription { get; set; }
        public DbSet<LocationType> LocationTypes { get; set; }
        public DbSet<OrganizerType> OrganizerTypes { get; set; }
        public DbSet<Origanizer> Origanizers { get; set; }
        public DbSet<Praticipant> Praticipants { get; set; }
        public DbSet<ProjectLevel> ProjectLevels { get; set; }
        public DbSet<StatusType> StatusTypes { get; set; }
        public DbSet<Student> Students { get; set; }
    }

}