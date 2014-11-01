namespace RashahlyKtab.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Migrations.Infrastructure;
    
    public partial class mergeEventsintoApplicationDBConext : DbMigration
    {
        public override void Up()
        {

            this.Sql(@"IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Events]') AND type in (N'U'))
                    Begin
                    CREATE TABLE [dbo].[Events](
	                    [Id] [int] IDENTITY(1,1) NOT NULL,
	                    [IsAtive] [bit] NOT NULL,
	                    [Title] [nvarchar](max) NOT NULL,
	                    [StartDate] [datetime] NOT NULL,
	                    [EndDate] [datetime] NOT NULL,
	                    [CreateionDate] [datetime] NOT NULL,
                     CONSTRAINT [PK_dbo.Events] PRIMARY KEY CLUSTERED 
                    (
	                    [Id] ASC
                    )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
                    ) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
                    End");
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Events");
        }
    }
}
