param($installPath, $toolsPath, $package, $project)

foreach ($reference in $project.Object.References)
{
   if(($reference.Name -ne "mscorlib") -and ($reference.Name -ne "System") -and (($reference.Name -notmatch "Microsoft.") -or ($reference.Name -match "Microsoft.Prac."))  -and ($reference.Name -notmatch "System.") ) 
   {
	   if($reference.CopyLocal -eq $true){
		   Write-Host "Setting CopyLocal to false on Reference "  $reference.Name  " of project "  $project.Name
		   $reference.CopyLocal = $false;
	   }
   }
}

foreach($item in $project.ProjectItems)
{
	if($item.Name -eq "CopyLocalFalse.txt")
	{
		$item.Remove()
	}
}

