
export default function Timer({ timer, loading, error }) {
    let timerr
    let time;

    if (timer != null) {
        timerr = JSON.parse(timer);

        let hours = Math.floor(timerr.total / 3600);
        let minutes = Math.floor((timerr.total % 3600) / 60);
        let seconds = timerr.total % 60;

        let hour = hours < 10 ? `0${hours}:` : `${hours}:`;
        let minute = minutes < 10 ? `0${minutes}:` : `${minutes}:`;
        let second = seconds < 10 ? `0${seconds}` : `${seconds}`;
        time = `${hour.toString()}${minute.toString()}${second.toString()}`;
    }

    if (loading) return <p>£adowanie...</p>;

    if (error) return <p>B³¹d: {error.message}</p>;

    return (
        <div className={`w-min-24 justify-self-end`}>
            <p>Timer: {timer != null ? (timerr != null ? time : "") : "brak wpisu"}</p>
        </div>
    );

}
