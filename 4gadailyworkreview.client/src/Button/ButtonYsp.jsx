export default function ButtonYsp({ name }) {
    function handleClick() {
        alert(`Ysp button ${name} clicked`);
    }

    return (
        <div className="relative">
            <button className="absolute place-items-end text-white font-bold bg-gray-700 br-10 box-border p-2 border-1 rounded-md border-black"  onClick={handleClick}>{name}</button>
        </div>
    )
}