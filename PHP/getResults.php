<?php
session_start();

require_once("UserController.php");
$uc = new UserController();

$user = $_POST['user'];
if($user == "Faculty")
{
	$result = $uc->getResults();
	

	foreach ($result as $row) {
		$scores = $uc->getScore($row['username']);
	foreach ($scores as $val) {
		
		
		echo "username:".$row['username'] . "|semester:".$row['semester']. "|studentId:".$row['studentId']. "|score:".$val['score'] . ";";
		}
	

	}
}
	

?>

