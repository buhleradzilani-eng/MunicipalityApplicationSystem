# Municipality Application System

A Windows Forms desktop application built with C# for reporting and managing municipal infrastructure issues. Citizens can report problems such as potholes, broken streetlights, and damaged infrastructure, with built-in gamification features to encourage participation.

## What this is

**Municipality Application System** is a civic engagement platform that enables citizens to report municipal issues directly through an intuitive desktop interface. The application uses gamification mechanics (XP rewards) to incentivize issue reporting and maintains a centralized repository of reported problems for municipal review and resolution.

## Stack

- **Language:** C#
- **Framework / runtime:** .NET 10.0 (Windows Forms for desktop UI)
- **Key technology:** Windows Forms (WinForms), .NET Class Libraries

## How it's organized

```
ApplicationClassLibrary/        Data model for issue management
  ├── ApplicationClassLibrary.csproj
  └── Issue.cs                 Issue entity with properties

MunicipalityApplicationSystem/  Main WinForms desktop application
  ├── MunicipalityApplicationSystem.csproj
  ├── Program.cs              Application entry point
  ├── MainForm.cs             Primary navigation form
  ├── MainForm.Designer.cs    UI designer-generated code
  ├── ReportIssueForm.cs      Form for submitting new issues
  ├── ReportIssueForm.Designer.cs
  ├── ShowIssuesForm.cs       Form for viewing submitted issues
  ├── ShowIssuesForm.Designer.cs
  ├── Properties/             Application settings and resources
  └── Resources/              UI resources

MunicipalityApplicationSystem.slnx   Solution file
```

### How it fits together

The application follows a three-form pattern:

1. **MainForm** - Serves as the entry point, providing navigation to issue reporting
2. **ReportIssueForm** - Allows users to submit new issues with:
   - Title, location, category, and description fields
   - File attachment support (images, documents)
   - Input validation on all required fields
   - Gamification rewards that award XP based on submission completeness
3. **ShowIssuesForm** - Displays all submitted issues in a formatted list view

The `Issue` class (from ApplicationClassLibrary) serves as the shared data model, storing issue metadata (title, location, category, description) and attachment paths. All issue instances are maintained in memory within each form session.

## How to run it

### Prerequisites
- .NET 10.0 SDK or later
- Windows operating system (WinForms requirement)
- Visual Studio 2022+ (recommended) or any C# IDE

### Build and Run

```bash
# Clone the repository
git clone https://github.com/buhleradzilani-eng/MunicipalityApplicationSystem.git
cd MunicipalityApplicationSystem

# Build the solution
dotnet build

# Run the application
dotnet run --project MunicipalityApplicationSystem/MunicipalityApplicationSystem.csproj
```

### Features

**Reporting Issues:**
- Submit issues with required fields: title, location, category, and description
- Attach supporting files (images, documents) to issues
- Real-time file preview for image attachments
- Form validation with helpful error messages

**Gamification System:**
- Base XP (50 points) for each issue reported
- +25 XP bonus for including file attachments
- +15 XP bonus for detailed descriptions (>50 characters)
- Progress tracking toward next level (100 XP per level)

**Viewing Issues:**
- Display all submitted reports in a formatted list
- View complete issue details including attachments
- Clear list functionality

## Try asking

- How does the gamification system calculate XP rewards for different types of issue submissions?
- Where is data persistence implemented (database or file storage)?
- How can I add new categories for municipal issue types?
- What validation rules are currently applied to issue submissions?
- How can the application be extended to support user authentication and persistent storage?
