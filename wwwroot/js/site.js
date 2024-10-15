const currentTheme = localStorage.getItem('theme') || 'dark-mode';
document.body.classList.add(currentTheme);

function toggleTheme() {
    const bodyClassList = document.body.classList;

    if (bodyClassList.contains('dark-mode')) {
        bodyClassList.replace('dark-mode', 'light-mode');
        localStorage.setItem('theme', 'light-mode');
    } else {
        bodyClassList.replace('light-mode', 'dark-mode');
        localStorage.setItem('theme', 'dark-mode');
    }
}
