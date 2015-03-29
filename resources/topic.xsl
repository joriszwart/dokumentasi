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

  <xsl:template match="FullName">
    <h1>
      <xsl:value-of select="."/>
    </h1>
  </xsl:template>

  <xsl:template match="Signature">
    <h1>
      <xsl:value-of select="."/>
    </h1>
  </xsl:template>

  <xsl:template match="Summary">
    <h2>Summary</h2>
    <p>
      <xsl:value-of select="."/>
    </p>
  </xsl:template>

  <xsl:template match="Syntax">
    <pre>
      <xsl:for-each select="Code">
        <code>
          <xsl:value-of select="."/>
        </code>
      </xsl:for-each>      
    </pre>
  </xsl:template>

  <xsl:template match="Inheritance">
    <h2>Inheritance</h2>

    <ul>
      <xsl:for-each select="Class">
        <xsl:text disable-output-escaping="yes">&lt;li&gt;</xsl:text>
        <a href="{@Id}">
          <xsl:value-of select="."/>
        </a>
      </xsl:for-each>
      <!-- close all <li> tags -->
      <xsl:for-each select="Class">
        <xsl:text disable-output-escaping="yes">&lt;/li&gt;</xsl:text>
      </xsl:for-each>
    </ul>

    <dl>
      <dt>
        Namespace
      </dt>
      <dd>
        <xsl:value-of select="@Namespace"/>
      </dd>
      <dt>
        Assembly
      </dt>
      <dd>
        <xsl:value-of select="@AssemblyName"/>
        (in <xsl:value-of select="@AssemblyFileName"/>)
      </dd>
    </dl>
  </xsl:template>

  <xsl:template match="Constructors|Properties|Methods|ExtensionMethods|Events|Fields">
    <table>
      <thead>
        <tr>
          <th></th>
          <th>Name</th>
          <th>Description</th>
        </tr>
      </thead>
      <xsl:for-each select="Member">
        <tbody>
          <tr>
            <xsl:value-of select="Properties"/>
          </tr>
          <tr>
            <xsl:value-of select="Name"/>
          </tr>
          <tr>
            <xsl:value-of select="Description"/>
          </tr>
        </tbody>
      </xsl:for-each>
    </table>
  </xsl:template>

  <xsl:template match="Remarks">
    <p>
      <xsl:value-of select="."/>
    </p>
  </xsl:template>

  <xsl:template match="Examples">
    <xsl:value-of select="."/>
  </xsl:template>

  <xsl:template match="SeeAlso">
    <ul>
      <xsl:for-each select="Item">
        <li>
          <xsl:value-of select="."/>
        </li>
      </xsl:for-each>
    </ul>
  </xsl:template>

</xsl:stylesheet>