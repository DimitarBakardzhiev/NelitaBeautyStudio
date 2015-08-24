function confirmDelete() {
    if (!confirm('Наистина ли искате да изтриете този запис?')) {
        event.preventDefault();
    }
}

function confirmPromoteDemote() {
    if (!confirm('Наистина ли искате да промените ролята на този потребител?')) {
        event.preventDefault();
    }
}