#####################################################
# This is an example of sending an email message using Google
# GMail SMTP server.
# All input parameters: From Address, To Address, Subject,
# Message Text, GMail username and password, are expected to be
# in a string format. 

def sendalert( fromaddr, toaddrs, subject, msgtext, username, password):
    import smtplib
    
    # Turn the input string of comma-separated recipient addresses
    # into a list as required by sendmail function
    toaddrs = toaddrs.split()
        
    message = """\From: %s\nTo: %s\nSubject: %s\n\n%s
        """ % (fromaddr, ", ".join(toaddrs), subject, msgtext)

    server = smtplib.SMTP('smtp.gmail.com:587')
    server.ehlo()
    server.starttls()
    
    # Provide GMail user and password information
    server.login(username,password)
    server.sendmail(fromaddr, toaddrs, message)
    server.quit()

#####################################################
