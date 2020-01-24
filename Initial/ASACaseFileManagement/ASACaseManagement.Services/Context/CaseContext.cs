using System;
using System.Collections.Generic;
using System.Text;
using ASACaseManagement.Services.Entities;
using Microsoft.EntityFrameworkCore;

namespace ASACaseManagement.Services.Context
{
    public class CaseContext: DbContext
    {
        public CaseContext(DbContextOptions<CaseContext> options)
            :base(options)
        {
        }

        public DbSet<CaseFile> CaseFiles { get; set; }
        public DbSet<Respondent> Respondents { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CaseFile>().HasData(
                new CaseFile
                {
                    Id = 1,
                    CaseNumber = "1001-001",
                    Title = "Disputes between a landlord and tenant",
                    Description = "Description of disputes between a landlord and tenant goes here.",
                    CreationDate = new DateTime(2020, 1, 1)
                },
                new CaseFile
                {
                    Id = 2,
                    CaseNumber = "2001-002",
                    Title = "Committed homicide felony offense",
                    Description = "Description of committed homicide felony offense goes here.",
                    CreationDate = new DateTime(2020, 1, 11)
                },
                new CaseFile
                {
                    Id = 3,
                    CaseNumber = "3001-003",
                    Title = "Traffic rules violation",
                    Description = "Description of traffic rules violation goes here.",
                    CreationDate = new DateTime(2020, 1, 22)
                }
            );

            modelBuilder.Entity<Respondent>().HasData(
                new Respondent
                {
                    Id = 1,
                    FirstName = "Shafiq",
                    LastName = "Anwar",
                    DateOfBirth = new DateTime(1988, 12, 20),
                    Address = "Village: V1, Post Office: PO1, Thana: T1, District: D1, Division: Dv1, Bangladesh",
                    CaseFileId = 1
                },
                new Respondent
                {
                    Id = 2,
                    FirstName = "Mohammad",
                    LastName = "Hasan",
                    DateOfBirth = new DateTime(1984, 11, 2),
                    Address = "Village: V2, Post Office: PO2, Thana: T2, District: D2, Division: Dv2, Bangladesh",
                    CaseFileId = 1
                },
                new Respondent
                {
                    Id = 3,
                    FirstName = "Ahmed",
                    LastName = "Arefin",
                    DateOfBirth = new DateTime(1988, 12, 1),
                    Address = "Village: V3, Post Office: PO3, Thana: T3, District: D3, Division: Dv3, Bangladesh",
                    CaseFileId = 2
                },
                new Respondent
                {
                    Id = 4,
                    FirstName = "Bilkis",
                    LastName = "Banu",
                    DateOfBirth = new DateTime(1988, 4, 20),
                    Address = "Village: V4, Post Office: PO4, Thana: T4, District: D4, Division: Dv4, Bangladesh",
                    CaseFileId = 2
                },
                new Respondent
                {
                    Id = 5,
                    FirstName = "Zebunnesa",
                    LastName = "Begum",
                    DateOfBirth = new DateTime(1996, 5, 4),
                    Address = "Village: V5, Post Office: PO5, Thana: T5, District: D5, Division: Dv5, Bangladesh",
                    CaseFileId = 3
                }
            );

            base.OnModelCreating(modelBuilder);
        }
    }
}
