import { useState, useEffect } from 'react';

export default function Project({ style, projectid }) {
    const [project, setProject] = useState();
    const [error, setError] = useState();
    const [loading, setLoading] = useState();

    useEffect(() => {
        const fetchRequest = async () => {
            try {
                const response = await fetch(`api/project/${projectid}`);

                if (!response.ok)
                    throw new error(`HTTP error status: ${response.status}`);

                const result = await response.json();

                setProject(result);
            } catch (error) {
                setError(error);
            } finally {
                setLoading(false);
            }
        }
        fetchRequest(projectid);

    }, [projectid]);

    if (loading) return <p>£adowanie...</p>;

    if (error) return <p>B³¹d: {error.message}</p>;

    return (
        <div className={`${style}`} >
            <p>Project: {project != null ? project.name : "Empty"}</p>
        </div>
    )
}