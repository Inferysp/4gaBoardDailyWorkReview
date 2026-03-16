export default function ButtonYsp({style, name }) {
    function handleClick() {
        alert(`Ysp button ${name} clicked`);
    }

    return (
        <div className={`${style}`}>
            <button className=""  onClick={handleClick}>{name}</button>
        </div>
    )
}