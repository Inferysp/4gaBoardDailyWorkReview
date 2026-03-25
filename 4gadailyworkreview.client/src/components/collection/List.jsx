import { useState, useEffect } from 'react';

export default function List({ style, listid }) {
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

    return (
        <div className={`${style}`}>
            <p>List: {list != null ? list.name  : "Brak"}</p>
        </div>
    )
}