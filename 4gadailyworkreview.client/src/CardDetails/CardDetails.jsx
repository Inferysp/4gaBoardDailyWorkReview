import { useEffect, useState } from 'react';

function CardDetails({ cardId }) {
    const [card, setCard] = useState(null);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState(null);

    useEffect(() => {
        // Adres Twojego API (sprawdŸ port w Properties/launchSettings.json)
        fetch(`/cards/${cardId}`)
            .then(response => {
                if (!response.ok) throw new Error(`Nie znaleziono karty ${cardId}`);
                return response.json();
            })
            .then(data => {
                setCard(data);
                setLoading(false);
            })
            .catch(err => {
                setError(err.message);
                setLoading(false);
            });
    }, [cardId]);

    if (loading) return <p>£adowanie...</p>;
    if (error) return <p>B³¹d: {error}</p>;

    return (
        <div>
            <h1>{card.name}</h1>
            <p>Opis: {card.description || 'Brak opisu'}</p>
            <small>Utworzono: {new Date(card.createdAt).toISOString()}</small>
        </div>
    );
}

export default CardDetails;
