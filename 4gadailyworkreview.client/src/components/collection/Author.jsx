import React from 'react';
import { useState, useEffect } from 'react';

export default function Author({ authorid, style }) {
    const [user, userSet] = useState(null);
    const [error, errorSet] = useState(null);
    const [loading, loadingSet] = useState(true);

    useEffect(() => {
        const fetchResult = async () => {
            try {
                const response = await fetch(`api/user/${authorid}`);

                const result = await response.json();

                if (!response.ok)
                    throw new Error(`HTTP error status: ${response.status}`);

                userSet(result);
            } catch (e) {
                errorSet(e);
            } finally {
                loadingSet(false);
            }
        } 

        fetchResult(authorid);
    }, [authorid]);

    if (loading) return <p>Loading...</p>

    if (error) return <p>Error: {error.message}</p>

    return (
        <div className={`${style} flex-1`}>
            <p>{user != null ? user.name : "Autor nie znany"}</p>
        </div>
    )

}