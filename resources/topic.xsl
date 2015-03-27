<?xml version="1.0" encoding="utf-8" ?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">

  <xsl:output method="html" omit-xml-declaration="yes" indent="yes" encoding="utf-8"/>
  <xsl:strip-space elements="*"/>

  <xsl:template match="/">
    <xsl:text disable-output-escaping="yes">&lt;!DOCTYPE html&gt;
</xsl:text>
    <html>
      <head>
        <meta charset="utf-8"/>
        <title><xsl:value-of select="@Id"/></title>
      </head>
      <body>
        <article>
        <xsl:apply-templates/>
        </article>
      </body>
    </html>
  </xsl:template>

</xsl:stylesheet>