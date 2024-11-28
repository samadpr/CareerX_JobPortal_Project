using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domain.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AuthUser",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    Password = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Status = table.Column<int>(type: "int", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__AuthUser__3214EC07D513CE6E", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Industry",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Industry__3214EC072DDCCCC8", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JobCategory",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__JobCateg__3214EC07783007E5", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JobSeeker",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    UserName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Image = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Role = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__JobSeeke__3214EC07478DBF8D", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Location__3214EC07432A7873", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Qualification",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Qualific__3214EC0779AAB97E", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SignUpRequests",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    UserName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__SignUpRe__3214EC0700B92B55", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Skill",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Skill__3214EC079F28E3DD", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JobSeekerProfile",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    JobSeekerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProfileName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ProfileSummary = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__JobSeeke__3214EC070C013632", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobSeekerProfile_JobSeeker",
                        column: x => x.JobSeekerId,
                        principalTable: "JobSeeker",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CompanyAdmin",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    LegalName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Summary = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IndustryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Phone = table.Column<long>(type: "bigint", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Website = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Location = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__CompanyA__3214EC0745D4C12C", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompanyAdmin_Industry",
                        column: x => x.IndustryId,
                        principalTable: "Industry",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CompanyAdmin_Location",
                        column: x => x.Location,
                        principalTable: "Location",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "JobSeekerProfileSkill",
                columns: table => new
                {
                    JobSeekerProfileId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SkillId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__JobSeeke__C66959E4A3925978", x => new { x.JobSeekerProfileId, x.SkillId });
                    table.ForeignKey(
                        name: "FK_JobSeekerProfileSkill_JobSeekerProfile",
                        column: x => x.JobSeekerProfileId,
                        principalTable: "JobSeekerProfile",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_JobSeekerProfileSkill_Skill",
                        column: x => x.SkillId,
                        principalTable: "Skill",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Resume",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    JobSeekerProfileId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ResumeFile = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    FileType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DateUploaded = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Resume__3214EC0748B6B243", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Resume_JobSeekerProfile",
                        column: x => x.JobSeekerProfileId,
                        principalTable: "JobSeekerProfile",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "HiringManager",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Image = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Role = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__HiringMa__3214EC0718E6366B", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HiringManager_CompanyAdmin",
                        column: x => x.CompanyId,
                        principalTable: "CompanyAdmin",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "JobPosts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    JobTitle = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    JobSummary = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LocationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IndustryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PostedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PostedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    QualificationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SkillId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__JobPosts__3214EC072487B189", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobPosts_Category",
                        column: x => x.CategoryId,
                        principalTable: "JobCategory",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_JobPosts_Company",
                        column: x => x.CompanyId,
                        principalTable: "CompanyAdmin",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_JobPosts_Industry",
                        column: x => x.IndustryId,
                        principalTable: "Industry",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_JobPosts_Location",
                        column: x => x.LocationId,
                        principalTable: "Location",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_JobPosts_PostedBy",
                        column: x => x.PostedBy,
                        principalTable: "HiringManager",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_JobPosts_Qualification",
                        column: x => x.QualificationId,
                        principalTable: "Qualification",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_JobPosts_Skill",
                        column: x => x.SkillId,
                        principalTable: "Skill",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "JobApplication",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    JobPostId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Applicant = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ResumeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CoverLetter = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateSubmitted = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__JobAppli__3214EC0777659508", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobApplication_Applicant",
                        column: x => x.Applicant,
                        principalTable: "JobSeeker",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_JobApplication_JobPost",
                        column: x => x.JobPostId,
                        principalTable: "JobPosts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_JobApplication_Resume",
                        column: x => x.ResumeId,
                        principalTable: "Resume",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SavedJobs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    Job = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SavedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateSaved = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__SavedJob__3214EC073D2C3B15", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SavedJobs_Job",
                        column: x => x.Job,
                        principalTable: "JobPosts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SavedJobs_JobSeeker",
                        column: x => x.SavedBy,
                        principalTable: "JobSeeker",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Interviews",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    JobId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Interviewee = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ApplicationId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime", nullable: true),
                    ScheduledBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Intervie__3214EC07F5413196", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Interview__Appli__07C12930",
                        column: x => x.ApplicationId,
                        principalTable: "JobApplication",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__Interview__Compa__09A971A2",
                        column: x => x.CompanyId,
                        principalTable: "CompanyAdmin",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__Interview__Inter__06CD04F7",
                        column: x => x.Interviewee,
                        principalTable: "JobSeeker",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__Interview__JobId__05D8E0BE",
                        column: x => x.JobId,
                        principalTable: "JobPosts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__Interview__Sched__08B54D69",
                        column: x => x.ScheduledBy,
                        principalTable: "HiringManager",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CompanyAdmin_IndustryId",
                table: "CompanyAdmin",
                column: "IndustryId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyAdmin_Location",
                table: "CompanyAdmin",
                column: "Location");

            migrationBuilder.CreateIndex(
                name: "IX_HiringManager_CompanyId",
                table: "HiringManager",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "UQ__HiringMa__A9D10534F09AB67E",
                table: "HiringManager",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Interviews_ApplicationId",
                table: "Interviews",
                column: "ApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_Interviews_CompanyId",
                table: "Interviews",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Interviews_Interviewee",
                table: "Interviews",
                column: "Interviewee");

            migrationBuilder.CreateIndex(
                name: "IX_Interviews_JobId",
                table: "Interviews",
                column: "JobId");

            migrationBuilder.CreateIndex(
                name: "IX_Interviews_ScheduledBy",
                table: "Interviews",
                column: "ScheduledBy");

            migrationBuilder.CreateIndex(
                name: "IX_JobApplication_Applicant",
                table: "JobApplication",
                column: "Applicant");

            migrationBuilder.CreateIndex(
                name: "IX_JobApplication_JobPostId",
                table: "JobApplication",
                column: "JobPostId");

            migrationBuilder.CreateIndex(
                name: "IX_JobApplication_ResumeId",
                table: "JobApplication",
                column: "ResumeId");

            migrationBuilder.CreateIndex(
                name: "IX_JobPosts_CategoryId",
                table: "JobPosts",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_JobPosts_CompanyId",
                table: "JobPosts",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_JobPosts_IndustryId",
                table: "JobPosts",
                column: "IndustryId");

            migrationBuilder.CreateIndex(
                name: "IX_JobPosts_LocationId",
                table: "JobPosts",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_JobPosts_PostedBy",
                table: "JobPosts",
                column: "PostedBy");

            migrationBuilder.CreateIndex(
                name: "IX_JobPosts_QualificationId",
                table: "JobPosts",
                column: "QualificationId");

            migrationBuilder.CreateIndex(
                name: "IX_JobPosts_SkillId",
                table: "JobPosts",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "UQ__JobSeeke__A9D10534039B4590",
                table: "JobSeeker",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_JobSeekerProfile_JobSeekerId",
                table: "JobSeekerProfile",
                column: "JobSeekerId");

            migrationBuilder.CreateIndex(
                name: "IX_JobSeekerProfileSkill_SkillId",
                table: "JobSeekerProfileSkill",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_Resume_JobSeekerProfileId",
                table: "Resume",
                column: "JobSeekerProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_SavedJobs_Job",
                table: "SavedJobs",
                column: "Job");

            migrationBuilder.CreateIndex(
                name: "IX_SavedJobs_SavedBy",
                table: "SavedJobs",
                column: "SavedBy");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuthUser");

            migrationBuilder.DropTable(
                name: "Interviews");

            migrationBuilder.DropTable(
                name: "JobSeekerProfileSkill");

            migrationBuilder.DropTable(
                name: "SavedJobs");

            migrationBuilder.DropTable(
                name: "SignUpRequests");

            migrationBuilder.DropTable(
                name: "JobApplication");

            migrationBuilder.DropTable(
                name: "JobPosts");

            migrationBuilder.DropTable(
                name: "Resume");

            migrationBuilder.DropTable(
                name: "JobCategory");

            migrationBuilder.DropTable(
                name: "HiringManager");

            migrationBuilder.DropTable(
                name: "Qualification");

            migrationBuilder.DropTable(
                name: "Skill");

            migrationBuilder.DropTable(
                name: "JobSeekerProfile");

            migrationBuilder.DropTable(
                name: "CompanyAdmin");

            migrationBuilder.DropTable(
                name: "JobSeeker");

            migrationBuilder.DropTable(
                name: "Industry");

            migrationBuilder.DropTable(
                name: "Location");
        }
    }
}
