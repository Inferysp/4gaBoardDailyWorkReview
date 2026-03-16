import { marked } from 'marked';

function Description({ markdown }) {
    const html = marked(markdown, {
        breaks: true,
        gfm: true
    });

    return (
        <div
            className="description"
            dangerouslySetInnerHTML={{ __html: html }}
        />
    );
}

export default Description;