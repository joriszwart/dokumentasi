<?xml version="1.0" encoding="utf-8" ?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">

  <xsl:output method="html" omit-xml-declaration="yes" indent="yes" encoding="utf-8"/>
  <xsl:strip-space elements="*"/>

  <xsl:param name="current"/>

  <xsl:template match="ArrayOfTypeInfo">
    <nav class="toc">
      <ul>
        <xsl:apply-templates/>
      </ul>
    </nav>
  </xsl:template>

  <xsl:template match="TypeInfo">
    <li>
      <xsl:attribute name="class">
        <xsl:if test="TypeInfo">has-childs </xsl:if>
        <xsl:if test="'' = $current">current </xsl:if>
      </xsl:attribute>
      <a href="{@Id}">
        <xsl:value-of select="FullName"/>
      </a>

      <xsl:if test="TypeInfo">
        <ul>
          <xsl:apply-templates/>
        </ul>
      </xsl:if>
    </li>
  </xsl:template>

</xsl:stylesheet>