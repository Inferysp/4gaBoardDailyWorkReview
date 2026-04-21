import { useState, useEffect } from 'react';

export default function List({ listid }) {
    const [list, setList] = useState();
    const [error, setError] = useState();
    const [loading, setLoading] = useState();

    useEffect(() => {


        const fetchRequest = async () => {
            try {
                const response = await fetch(`api/list/${listid}`);

                if (!response.ok)
                    throw new error(`HTTP error status: ${response.status}`);

                const result = await response.json();

                setList(result);

            } catch (error) {
                setError(error);
            } finally {
                setLoading(false);
            }
        }

        fetchRequest(listid);
    }, [listid])

    if (loading) return <p>£adowanie...</p>;

    if (error) return <p>B³¹d: {error.message}</p>;

    return (
        <div className="listTopBar flex gap-x-1">
            <p>List:</p><p className="italicText">{list != null ? list.name  : "Brak"}</p>
        </div>
    )
}