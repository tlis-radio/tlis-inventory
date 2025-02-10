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

document.addEventListener("DOMContentLoaded", function () {
	let tagContainer = document.getElementById("tag-container");
	let tagInput = document.getElementById("tag-input");
	let hiddenTags = document.getElementById("tagsHidden");
	let tags = [];
	hiddenTags.value = JSON.stringify(tags);

	tagInput.addEventListener("keypress", function (event) {
		if (event.key === "Enter") {
			event.preventDefault();
			let tagText = tagInput.value.trim();

			if (tagText !== "" && !tags.includes(tagText)) {
				tags.push(tagText);
				renderTags();
			}

			tagInput.value = "";
		}
	});

	function renderTags() {
		tagContainer.innerHTML = "";

		tags.forEach((tag, index) => {

			let cross = '<svg xmlns="http://www.w3.org/2000/svg" class="h-full" viewBox="0 0 24 24" fill="none">'+
					'<path d="M16 8L8 16M12 12L16 16M8 8L10 10" stroke-width="1.5" stroke-linecap="round" stroke-linejoin="round"/>'+
					'</svg>'
			let tagElement = document.createElement("span");
			tagElement.className = "flex justify-center w-fit px-1 rounded-md border border-azure bg-electric-blue/50";
			tagElement.innerHTML = `${tag} <span class="ml-2 stroke-chili-red cursor-pointer size-6" onclick="removeTag(${index})">${cross}</span>`;
			tagContainer.appendChild(tagElement);
		});

		tagContainer.appendChild(tagInput);
		hiddenTags.value = JSON.stringify(tags);
	}

	window.removeTag = function (index) {
		tags.splice(index, 1);
		renderTags();
	};
});