## Compiler Defines

As of UniVerse V11.2, there are now preloaded DEFINES built into the compiler.

Compiler DEFINES enable condition compile basic on database type and version:  

```
$IFDEF U2_UNIVERSE
$IFDEF U2_UNIVERSEv11
$IFDEF U2_UNIVERSEv11.2
```

UniData and UniVerse both have different subroutine signatures for the security subroutine used by REMOTE VOCs. The 'securitySub' subroutine shows you how you could use some of these new DEFINEs.
