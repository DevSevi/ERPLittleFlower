const puppeteer = require('puppeteer');
const fs = require('fs');
const markdownIt = require('markdown-it');
const md = markdownIt();

// Markdown-Datei einlesen
const markdown = fs.readFileSync('/Users/severinkiener/src/ERPLittleFlower/ERPLittleFlower/dokumentation/Arbeitsdokumentation.md', 'utf8');
const htmlContent = md.render(markdown);

(async () => {
  const browser = await puppeteer.launch({ headless: true });
  const page = await browser.newPage();

  // HTML mit Mermaid einbinden
  await page.setContent(`
    <html>
      <head>
        <script src="https://cdn.jsdelivr.net/npm/mermaid@10/dist/mermaid.min.js"></script>
        <script>
          document.addEventListener("DOMContentLoaded", function() {
            mermaid.initialize({ startOnLoad:true });
          });
        </script>
        <style>
          body { font-family: Arial, sans-serif; margin: 40px; }
          h1,h2,h3 { page-break-after: avoid; }
        </style>
      </head>
      <body>${htmlContent}</body>
    </html>
  `, { waitUntil: 'networkidle0' });

  // Warten, bis Mermaid die Diagramme gerendert hat
  await page.evaluate(async () => {
    const mermaids = document.querySelectorAll('.language-mermaid');
    for (const block of mermaids) {
      const code = block.textContent;
      const div = document.createElement('div');
      div.className = 'mermaid';
      div.textContent = code;
      block.parentNode.replaceWith(div);
    }
    mermaid.init(undefined, document.querySelectorAll('.mermaid'));
    await new Promise(resolve => setTimeout(resolve, 500)); // kleine Wartezeit für Render
  });

  // PDF erstellen
  await page.pdf({
    path: '/Users/severinkiener/Desktop/Arbeitsdokumentation.pdf',
    format: 'A4',
    displayHeaderFooter: true,
    headerTemplate: '<span></span>',
    footerTemplate: '<div style="font-size:10px;width:100%;text-align:center;">Seite <span class="pageNumber"></span> von <span class="totalPages"></span></div>',
    margin: { top: '40px', bottom: '60px', left: '40px', right: '40px' }
  });

  await browser.close();
})();