<?php
include "db.php";
if ($_SERVER['REQUEST_METHOD'] === 'POST') {
    $data = json_decode(file_get_contents('php://input'), true);
    mysqli_query($GLOBALS['mysqli'], "DELETE FROM objects WHERE 1");
    foreach ($data['objects'] as $object) {
        mysqli_query($GLOBALS['mysqli'], "INSERT INTO objects (prefabId, contentType, content, posX, posY, posZ, rotX, rotY, rotZ, scaleX, scaleY, scaleZ)");
    }
    echo '{}';
} else {
    $data = mysqli_query($GLOBALS['mysqli'], "SELECT * FROM objects");
    echo json_encode($data);
}
?>