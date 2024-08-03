--enable database mail
sp_configure 'show advanced options', 1;
GO
RECONFIGURE;
GO
 
sp_configure 'Database Mail XPs', 1;
GO
RECONFIGURE
GO

-- Create a Database Mail profile  
EXECUTE msdb.dbo.sysmail_add_profile_sp  
    @profile_name = 'WebDoki',  
    @description = 'WebDoki notifications' ;  
GO

--create SMTP account
EXECUTE msdb.dbo.sysmail_add_account_sp  
    @account_name = 'Mail',  
    @description = 'Mail account for sending outgoing notifications.',  
    @email_address = 'your email',  
    @display_name = 'WebDoki Notify System',  
    @mailserver_name = 'your mail server',
    @port = 587, --587 or 465
    @enable_ssl = 1,
    @username = 'your username',
    @password = 'your password';  
GO

-- Add the account to the profile  
EXECUTE msdb.dbo.sysmail_add_profileaccount_sp  
    @profile_name = 'WebDoki',  
    @account_name = 'Mail',  
    @sequence_number =1 ;  
GO