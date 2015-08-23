function confirmDelete() {
    if (!confirm('Наистина ли искате да изтриете този запис?')) {
        event.preventDefault();
    }
}