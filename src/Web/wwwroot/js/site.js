// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


function toggle_nav_menu() {
	let nav_menu = document.getElementById("nav-menu")
	
	let value = nav_menu.ariaHidden
	
	if (value === "true")
		nav_menu.ariaHidden = "false"
	else
		nav_menu.ariaHidden = "true"
}