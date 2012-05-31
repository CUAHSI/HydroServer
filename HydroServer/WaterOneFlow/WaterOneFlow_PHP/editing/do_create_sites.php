<?php
if (isset($_POST['data'])) {
	echo "<form action='create_sites.php' method='post' name='frm'>";
	foreach ($_POST as $a => $b) {
		echo "<input type='hidden' name='".$a."' value='".$b."'>";
	}
}
?>
</form>
<script language="JavaScript">
//alert(document.referrer);
document.frm.submit();

</script>