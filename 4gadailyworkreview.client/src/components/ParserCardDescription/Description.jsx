import { marked } from 'marked';

function Description({style, markdown }) {
    const html = marked(markdown, {
        breaks: true,
        gfm: true
    });

    return (
        <div
            class="description"
            dangerouslySetInnerHTML={{ __html: html }}
        />
    );
}

export default Description;