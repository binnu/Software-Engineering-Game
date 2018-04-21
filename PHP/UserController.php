<?php


class UserController {
	
	private $conn;
	
	function __construct() {
		require('dbConnection.php');
		$db = new DB();
		$this->conn = $db->get_connection();
	}
	//User Login validation
	function validateLogin($username , $password){

		$results = array();
		
		$valid = true;
		try{
			$query = "SELECT password FROM users WHERE username= :username ";

			$stmt = $this->conn->prepare($query);
			$stmt->bindValue(':username', $username, PDO::PARAM_STR);				
			$stmt->execute();
			while ($row = $stmt->fetch())
			{
				$password_hashed = $row[0];
			}

			if ( password_verify($password,$password_hashed)){

					$_SESSION['username'] = $username;
					
			}else{
				
				$valid = false;
			}
		}
		catch (PDOException $e) {
			echo 'Exception: ' . $e->getMessage();
		}
		
		return $valid;
	}
	
	
	
	//checking for existing user
	function ifUserExists($username , $email)
	{
		try{
			$exist = false;
			
			// Prepare the SQL statement and execute it
			$sql = "select COUNT(*) from users where username = :username or email = :email";
			$stmt = $this->conn->prepare($sql);
			$stmt->bindValue(':username', $username, PDO::PARAM_STR);
			$stmt->bindValue(':email', $email, PDO::PARAM_STR);				
			$stmt->execute();
		
			
			while ($row = $stmt->fetch()){
				error_log("result is .$row[0].");
				if($row[0] == 1){
					$exist = true;
				}
				
			}
			$stmt->closeCursor();
			
			// Close connections
			$stmt = null;
			$connection = null;
			
		} catch (PDOException $e) {
			echo "Exception: ".$e->getMessage();
			
		}
		
		return $exist;
	}			
	
	//insert new user details
	function insertUser($username,$password,$semester,$studentId,$email){
		$results = array();
		
		try{
			
			// Prepare the SQL statement and execute it
			$sql = "insert into users values(:username , :password , :semester , :studentId , :email)";
				$stmt = $this->conn->prepare($sql);
				$stmt->bindValue(':username', $username, PDO::PARAM_STR);
				$stmt->bindValue(':password', $password, PDO::PARAM_STR);
				$stmt->bindValue(':semester', $semester, PDO::PARAM_STR);
				$stmt->bindValue(':studentId', $studentId, PDO::PARAM_STR);
				$stmt->bindValue(':email', $email, PDO::PARAM_STR);
				
				$stmt->execute();		
				$stmt->closeCursor();
				
				
				
				$results = $this->conn->query("select @_return_value")->fetch(PDO::FETCH_ASSOC);
				
			// Close connections
				$stmt = null;
				$connection = null;
				
			} catch (PDOException $e) {
				echo 'Exception: ' . $e->getMessage();
			}
			
			return $results;
		}


		function insertScore($username,$score){
		$results = array();
		
		try{
			
			// Prepare the SQL statement and execute it
			$sql = "insert into result (username,score) values (:username , :score)";
				$stmt = $this->conn->prepare($sql);
				$stmt->bindValue(':username', $username, PDO::PARAM_STR);
				$stmt->bindValue(':score', $score, PDO::PARAM_STR);
				
				
				$stmt->execute();		
				$stmt->closeCursor();
				
				
				
				$results = $this->conn->query("select @_return_value")->fetch(PDO::FETCH_ASSOC);
				
			// Close connections
				$stmt = null;
				$connection = null;
				
			} catch (PDOException $e) {
				echo 'Exception: ' . $e->getMessage();
			}
			
			return $results;
		}
		
function getResults(){
		try{
		$sql = "select username,semester,studentId from users";
		$stmt = $this->conn->prepare($sql);
			$stmt->execute();
            $result = $stmt->fetchAll();
			
		}
		catch (PDOException $e) {
			echo 'Exception: ' . $e->getMessage();
		}

		return $result;
	}

	function getScore($username){
		try{
		$sql = "select score from result where created in (select max(created) from result where username = :username)";
		$stmt = $this->conn->prepare($sql);
		$stmt->bindValue(':username', $username, PDO::PARAM_STR);
			$stmt->execute();
            $result = $stmt->fetchAll();
			
		}
		catch (PDOException $e) {
			echo 'Exception: ' . $e->getMessage();
		}

		return $result;
	}
	

	function getEmailId($firstname,$lastname){
		try{
		$sql = "select email from users where first_name = :firstname and last_name = :lastname";
		$stmt = $this->conn->prepare($sql);
		$stmt->bindValue(':firstname', $firstname, PDO::PARAM_STR);
			$stmt->bindValue(':lastname', $lastname, PDO::PARAM_STR);
			$stmt->execute();
            $result = $stmt->fetch(PDO::FETCH_ASSOC);
			$email = $result['email'];
		}
		catch (PDOException $e) {
			echo 'Exception: ' . $e->getMessage();
		}

		return $email;
	}
}	